import { Button, SelectChangeEvent } from "@mui/material";
import { ChangeEvent, SyntheticEvent, useEffect, useState } from "react";
import { useTranslation } from "react-i18next";
import CheckIcon from "@mui/icons-material/Check";
import TerminalSettingsTabs from "../../components/cards/settings/card_terminal/terminalSettingsTabs";
import TerminalSettingsForm from "../../components/cards/settings/card_terminal/terminalSettingsForm";

export default function Terminal() {
  const { t } = useTranslation("common");
  const tabNames = [
    t("terminalSettings"),
    t("localNetwork"),
    t("actionsThatRequireAdminPassword"),
  ];

  const [settingsList, setSettingsList] = useState([
    {
      terminalLanguage: "",
      terminalLanguageOptions: [],
      applyServiceChargeRate: false,
      serviceChargePercentage: 0,
      multipleTerminalPermissions: false,
      singleReceiptAccess: false,
      autoPrintReceipts: false,
      showClientsInTerminal: false,
      productQuantityVisibility: false,
    },
    {
      localNetwork: false,
      mainTerminal: "",
      mainTerminalOptions: [],
    },
    {
      adminPassword: "",
      removeProduct: false,
    },
  ]);

  useEffect(() => {
    document.title = `${t("terminal")} / ${tabNames[tabIndex]}`;
  }, [t, tabNames]);

  const [tabIndex, setTabIndex] = useState(0);

  const handleChange = (
    e: ChangeEvent<HTMLInputElement | HTMLSelectElement> | SelectChangeEvent
  ) => {
    const target = e.target as HTMLInputElement | HTMLSelectElement;
    const { name, type } = target;

    let newValue: string | boolean | number;

    if (type === "checkbox") {
      newValue = (target as HTMLInputElement).checked;
    } else if (type === "number") {
      newValue = parseFloat(target.value);
    } else {
      newValue = target.value;
    }

    setSettingsList((prevSettings) => {
      const updatedSettings = [...prevSettings];
      updatedSettings[tabIndex] = {
        ...updatedSettings[tabIndex],
        [name]: newValue,
      };
      return updatedSettings;
    });
  };

  const handleTabChange = (e: SyntheticEvent, newValue: number) => {
    e.target;
    setTabIndex(newValue);
  };

  return (
    <div>
      <span className="text-gray-500 font-medium text-xl">
        {t("terminal")} / {tabNames[tabIndex]}
      </span>
      <div className="p-2">
        <TerminalSettingsTabs
          tabIndex={tabIndex}
          handleTabChange={handleTabChange}
        />
        <TerminalSettingsForm
          tabIndex={tabIndex}
          settings={settingsList[tabIndex]}
          handleChange={handleChange}
          t={t}
        />
        <Button
          variant="contained"
          className="mt-2 w-[130px] h-[35px] shadow-none"
          sx={{
            backgroundColor: "#4caf50",
            color: "white",
            textTransform: "none",
            boxShadow: "none",
            borderRadius: "10px",
            marginTop: "20px",
            "&:hover": {
              backgroundColor: "#388e3c",
            },
          }}
        >
          <span className="flex justify-center items-center">
            <CheckIcon />
            <span className="ml-2">{t("save")}</span>
          </span>
        </Button>
      </div>
    </div>
  );
}
