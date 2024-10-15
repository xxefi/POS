import { ChangeEvent, SyntheticEvent, useEffect } from "react";
import { useTranslation } from "react-i18next";
import { Button, Box } from "@mui/material";
import { useState } from "react";
import CheckIcon from "@mui/icons-material/Check";
import GeneralSettingsTabs from "../../components/cards/settings/card_general/generalSettingsTabs";
import GeneralSettingsForm from "../../components/cards/settings/card_general/generalSettingsForm";
import { SelectChangeEvent } from "@mui/material";

export default function General() {
  const { t } = useTranslation("common");
  const [settings, setSettings] = useState({
    brandName: "",
    tin: "",
    wifiName: "",
    wifiPassword: "",
    cashRegister: "",
    timezone: "",
    language: "",
    currency: "",
    googleMapsUrl: "",
    city: "",
    zip: "",
    address: "",
    phone: "",
    socialNetworks: "",
    workingHours: "",
    canCustomerBalanceBeNegative: false,
    selectedTerminalAccount: "",
  });

  useEffect(() => {
    document.title = t("general");
  }, [t]);

  const [tabIndex, setTabIndex] = useState(0);

  const handleChange = (
    e: ChangeEvent<HTMLInputElement | HTMLSelectElement> | SelectChangeEvent
  ) => {
    const target = e.target as HTMLInputElement | HTMLSelectElement;
    const { name, value } = target;

    const isCheckbox = target.type === "checkbox";
    const newValue = isCheckbox
      ? (e.target as HTMLInputElement).checked
      : value;

    setSettings((prevSettings) => ({
      ...prevSettings,
      [name]: newValue,
    }));
  };

  const handleTabChange = (e: SyntheticEvent, newValue: number) => {
    setTabIndex(newValue);
  };

  return (
    <div>
      <span className="text-gray-500 font-medium text-xl">{t("general")}</span>
      <div className="p-2">
        <GeneralSettingsTabs
          tabIndex={tabIndex}
          handleTabChange={handleTabChange}
        />
        <Box sx={{ mt: 2 }}>
          <GeneralSettingsForm
            tabIndex={tabIndex}
            settings={settings}
            handleChange={handleChange}
            t={t}
          />
        </Box>
        <Button
          variant="contained"
          className="mt-2 w-[130px] h-[35px] shadow-none"
          sx={{
            backgroundColor: "#4caf50",
            color: "white",
            textTransform: "none",
            boxShadow: "none",
            borderRadius: "10px",
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
