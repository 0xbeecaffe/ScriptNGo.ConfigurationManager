/* #########################################################################*/
/* #                                                                       #*/
/* #  This file is part of ConfigurationManager project, which is written  #*/
/* #  as a Script N'Go plug-in to help configuration management of         #*/
/* #  Cisco devices.                                                       #*/
/* #                                                                       #*/
/* #  You may not use this file except in compliance with the license.     #*/
/* #                                                                       #*/
/* #  Copyright Laszlo Frank (c) 2014-2020                                 #*/
/* #                                                                       #*/
/* #########################################################################*/

namespace Scriptngo.ConfigurationManager.Properties
{


  // This class allows you to handle specific events on the settings class:
  //  The SettingChanging event is raised before a setting's value is changed.
  //  The PropertyChanged event is raised after a setting's value is changed.
  //  The SettingsLoaded event is raised after the setting values are loaded.
  //  The SettingsSaving event is raised before the setting values are saved.

  internal sealed partial class Settings
  {

    public Settings()
    {
      // // To add event handlers for saving and changing settings, uncomment the lines below:
      //
      // this.SettingChanging += this.SettingChangingEventHandler;
      //
      // this.SettingsSaving += this.SettingsSavingEventHandler;
      //
      this.SettingsLoaded += Settings_SettingsLoaded;
      this.PropertyChanged += Settings_PropertyChanged;
    }

    private void Settings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (e.PropertyName == "SQLServerName" || e.PropertyName == "DatabaseName" || e.PropertyName == "SQLServerUsername" || e.PropertyName == "SQLServerPassword" || e.PropertyName == "SQLIntegratedSecurity")
      {
        if (this.SQLIntegratedSecurity)
        {
          this["PGTConnectionString"] = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", this.SQLServerName, this.DatabaseName);
        }
        else
        {
          this["PGTConnectionString"] = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", this.SQLServerName, this.DatabaseName, this.SQLServerUsername, this.SQLServerPassword);
        }
      }
    }

    void Settings_SettingsLoaded(object sender, System.Configuration.SettingsLoadedEventArgs e)
    {
      if (this.SQLIntegratedSecurity)
      {
        this["PGTConnectionString"] = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", this.SQLServerName, this.DatabaseName);
      }
      else
      {
        this["PGTConnectionString"] = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", this.SQLServerName, this.DatabaseName, this.SQLServerUsername, this.SQLServerPassword);
      }
    }
    private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e)
    {
      // Add code to handle the SettingChangingEvent event here.
    }

    private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
    {
      // Add code to handle the SettingsSaving event here.
    }
  }
}
