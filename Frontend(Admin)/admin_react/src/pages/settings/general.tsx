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
  const tabNames = [t("brandSetting"), t("finance"), t("productReturn")];
  const [settingsList, setSettingsList] = useState([
    {
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
    },
    {
      canCustomerBalanceBeNegative: false,
      selectedTerminalAccount: "",
      selectedTerminalAccountOptions: [],
    },
    {
      productReturn: false,
      returnOfDiscountedReceipt: false,
      maximumDayOfProductReturn: 0,
      returnsStorage: "",
      returnsStorageOptions: [],
    },
  ]);

  useEffect(() => {
    document.title = `${t("general")} / ${tabNames[tabIndex]}`;
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
        {t("general")} / {tabNames[tabIndex]}
      </span>
      <div className="p-2">
        <GeneralSettingsTabs
          tabIndex={tabIndex}
          handleTabChange={handleTabChange}
        />
        <Box sx={{ mt: 2 }}>
          <GeneralSettingsForm
            tabIndex={tabIndex}
            settings={settingsList[tabIndex]}
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
