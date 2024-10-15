import { Tabs, Tab } from "@mui/material";
import { SyntheticEvent } from "react";
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

  return (
    <Tabs
      value={tabIndex}
      onChange={handleTabChange}
      aria-label="settings tabs"
      sx={{ marginLeft: "-23px" }}
    >
      <Tab label={t("brandSetting")} sx={{ textTransform: "none" }} />
      <Tab label={t("finance")} sx={{ textTransform: "none" }} />
      <Tab label={t("productReturn")} sx={{ textTransform: "none" }} />
    </Tabs>
  );
}
