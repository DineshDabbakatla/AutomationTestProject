using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using FrameworkLayer.WebAppUtil;
using log4net.Config;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FrameworkLayer;

namespace SauceDemoTest.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static WebDriverUtils _driverUtils;
        IWebDriver _driver;
        TestSettings _settings = ConfigReader.GetConfig(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\appSettings.json");

        Hooks(WebDriverUtils driverUtils)
        {
            _driverUtils=driverUtils;
        }

        [BeforeTestRun]
        public static void InitializeReportAndLogging()
        {
            
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            Log.Info("Log4net initialized.");

            var htmlReporter = new ExtentSparkReporter(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\ExtentReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            Log.Info("ExtentReports initialized.");
        }

        [BeforeScenario]
        public void Initialize()
        {
            _driver = _driverUtils.GetDriver(_settings.Browser);
            _test = _extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
            Log.Info($"Starting scenario: {ScenarioContext.Current.ScenarioInfo.Title}");
        }

        [AfterScenario]
        public void CleanUp()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                _test.Fail(ScenarioContext.Current.TestError.Message);
                string screenshotPath = _driverUtils.TakeScreenShot(ScenarioContext.Current.ScenarioInfo.Title);
                _test.AddScreenCaptureFromPath(screenshotPath);
                Log.Error($"Scenario failed: {ScenarioContext.Current.ScenarioInfo.Title}", ScenarioContext.Current.TestError);
            }
            else
            {
                _test.Pass("Test passed");
                Log.Info($"Scenario passed: {ScenarioContext.Current.ScenarioInfo.Title}");
            }
            _driverUtils.QuitDriver();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            _extent.Flush();
            Log.Info("ExtentReports flushed.");
        }
    }
}
