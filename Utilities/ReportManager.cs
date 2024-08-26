using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace WebShopAutomation.Reporting
{
    public static class ReportManager
    {
        private static ExtentReports? extentReports;
        private static ExtentSparkReporter? sparkReporter;
        private static readonly string reportDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExtentReports");
        private static readonly string reportPath = Path.Combine(reportDirectory, "Spark.html");

        public static ExtentReports GetExtentReports()
        {
            if (extentReports == null)
            {
                try
                {
                    // Ensure the directory exists
                    if (!Directory.Exists(reportDirectory))
                    {
                        Directory.CreateDirectory(reportDirectory);
                    }

                    // Create an instance of ExtentReports
                    extentReports = new ExtentReports();

                    // Create an instance of ExtentSparkReporter
                    sparkReporter = new ExtentSparkReporter(reportPath)
                    {
                        Config =
                        {
                            ReportName = "Automation Test Report",
                            DocumentTitle = "Extent Report"
                        }
                    };

                    // Attach the reporter to the ExtentReports instance
                    extentReports.AttachReporter(sparkReporter);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error initializing ExtentReports: {ex.Message}");
                    throw;
                }
            }
            return extentReports;
        }

        public static void FlushReports()
        {
            try
            {
                extentReports?.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error flushing ExtentReports: {ex.Message}");
                throw;
            }
        }
    }
}
