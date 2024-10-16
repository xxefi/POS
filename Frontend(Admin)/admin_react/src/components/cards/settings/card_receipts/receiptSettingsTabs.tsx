import { Tab, Tabs } from "@mui/material";
import { CSSProperties, SyntheticEvent } from "react";
import { useTranslation } from "react-i18next";

interface SettingsTabsProps {
  tabIndex: number;
  handleTabChange: (e: SyntheticEvent, newValue: number) => void;
}

export default function ReceiptSettingsTabs({
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
      <Tab label={t("receipt")} style={tabsStyle} />
      <Tab label={t("action")} style={tabsStyle} />
      <Tab label={t("constructor")} style={tabsStyle} />
      <Tab label={t("stationConstructor")} style={tabsStyle} />
    </Tabs>
  );
}
