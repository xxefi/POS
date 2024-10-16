import { Tabs, Tab } from "@mui/material";
import { CSSProperties, SyntheticEvent } from "react";
import { useTranslation } from "react-i18next";

interface TerminalTabsProps {
  tabIndex: number;
  handleTabChange: (e: SyntheticEvent, newValue: number) => void;
}

export default function TerminalSettingsTabs({
  tabIndex,
  handleTabChange,
}: TerminalTabsProps) {
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
      <Tab label={t("terminalSettings")} style={tabsStyle} />
      <Tab label={t("localNetwork")} style={tabsStyle} />
      <Tab label={t("actionsThatRequireAdminPassword")} style={tabsStyle} />
    </Tabs>
  );
}
