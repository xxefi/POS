import { Tabs, Tab } from "@mui/material";
import { CSSProperties, SyntheticEvent } from "react";
import { useTranslation } from "react-i18next";

interface SettingsTabsProps {
  tabIndex: number;
  handleTabChange: (e: SyntheticEvent, newValue: number) => void;
}

export default function GeneralSettingsTabs({
  tabIndex,
  handleTabChange,
}: SettingsTabsProps) {
  const { t } = useTranslation("common");

  const tabsStyle: CSSProperties = {
    textTransform: "none",
  };

  return (
    <Tabs
      value={tabIndex}
      onChange={handleTabChange}
      aria-label="settings tabs"
      sx={{ marginLeft: "-23px" }}
    >
      <Tab label={t("brandSetting")} style={tabsStyle} />
      <Tab label={t("finance")} style={tabsStyle} />
      <Tab label={t("productReturn")} style={tabsStyle} />
    </Tabs>
  );
}
