using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace estimoteXamarin.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string estimoteNotificationChannelId = "estimoteNotificationChannelId";
        private static readonly string EstimoteNotificationChannelIdDefault = "proximity_scanning";

        private const string appIdEstimote = "appIdEstimote";
        private static readonly string appIdEstimoteDefault = "test-xamarin-io8";

        private const string appTokenEstimote = "appTokenEstimote";
        private static readonly string appTokenEstimoteDefault = "f03827075acaaba5b6fbc52436f1d4b6";

        private const string defaultProximityZoneKey = "defaultProximityZoneKey";
        private static readonly string defaultProximityZoneKeyDefault = "AuparDefaultZone";

        private const string defaultProximityZoneValue = "defaultProximityZone";
        private static readonly string defaultProximityZoneValueDefault = "AuparDefaultZone";

        private const string defaultProximityZoneDistance = "defaultProximityZoneDistance";
        private static readonly double defaultProximityZoneDistanceDefault = 5;

        private const string customProximityZoneKey = "customProximityZoneKey";
        private static readonly string customProximityZoneKeyDefault = "AuparCustomZone";

        private const string customProximityZoneValue = "customProximityZone";
        private static readonly string customProximityZoneValueDefault = "AuparCustomZone";

        private const string dbPath = "dbPath";
        private static readonly string dbPathDefault = string.Empty;

        #endregion


        public static string EstimoteNotificationChannelId
        {
            get
            {
                return AppSettings.GetValueOrDefault(estimoteNotificationChannelId, EstimoteNotificationChannelIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(estimoteNotificationChannelId, value);
            }
        }

        public static string AppIdEstimote
        {
            get
            {
                return AppSettings.GetValueOrDefault(appIdEstimote, appIdEstimoteDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(appIdEstimote, value);
            }
        }

        public static string AppTokenEstimote
        {
            get
            {
                return AppSettings.GetValueOrDefault(appTokenEstimote, appTokenEstimoteDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(appTokenEstimote, value);
            }
        }

        public static string DefaultProximityZoneKey
        {
            get
            {
                return AppSettings.GetValueOrDefault(defaultProximityZoneKey, defaultProximityZoneKeyDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(defaultProximityZoneKey, value);
            }
        }

        public static string DefaultProximityZoneValue
        {
            get
            {
                return AppSettings.GetValueOrDefault(defaultProximityZoneValue, defaultProximityZoneValueDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(defaultProximityZoneValue, value);
            }
        }

        public static double DefaultProximityZoneDistance
        {
            get
            {
                return AppSettings.GetValueOrDefault(defaultProximityZoneDistance, defaultProximityZoneDistanceDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(defaultProximityZoneDistance, value);
            }
        }

        public static string CustomProximityZoneKey
        {
            get
            {
                return AppSettings.GetValueOrDefault(customProximityZoneKey, customProximityZoneKeyDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(customProximityZoneKey, value);
            }
        }

        public static string CustomProximityZoneValue
        {
            get
            {
                return AppSettings.GetValueOrDefault(customProximityZoneValue, customProximityZoneValueDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(customProximityZoneValue, value);
            }
        }

        public static string DbPath
        {
            get
            {
                return AppSettings.GetValueOrDefault(dbPath, dbPathDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(dbPath, value);
            }
        }
    }
}
