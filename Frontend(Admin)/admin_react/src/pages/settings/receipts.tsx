import { Box, Button, SelectChangeEvent } from "@mui/material";
import { ChangeEvent, SyntheticEvent, useEffect, useState } from "react";
import { useTranslation } from "react-i18next";
import CheckIcon from "@mui/icons-material/Check";
import ReceiptSettingsForm from "../../components/cards/settings/card_receipts/receiptSettingsForm";
import ReceiptSettingsTabs from "../../components/cards/settings/card_receipts/receiptSettingsTabs";
import ReceiptCanvas from "../../components/cards/settings/card_receipts/receiptCanvas";
import { DndProvider } from "react-dnd";
import { HTML5Backend } from "react-dnd-html5-backend";

export default function Receipts() {
  const { t } = useTranslation("common");
  const tabNames = [
    t("receipt"),
    t("action"),
    t("constructor"),
    t("stationConstructor"),
  ];

  const [settingsList, setSettingsList] = useState([
    {
      receiptsLanguage: "",
      receiptsLanguageOptions: [],
      printTwice: false,
    },
    {},
    {},
  ]);

  useEffect(() => {
    document.title = `${t("receipts")} / ${tabNames[tabIndex]}`;
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
        {t("receipts")} / {tabNames[tabIndex]}
      </span>
      <div className="p-2">
        <Box sx={{ mt: 2 }}>
          <ReceiptSettingsTabs
            tabIndex={tabIndex}
            handleTabChange={handleTabChange}
          />
          <ReceiptSettingsForm
            tabIndex={tabIndex}
            settings={settingsList[tabIndex]}
            handleChange={handleChange}
            t={t}
          />
          {tabIndex === 2 && (
            <DndProvider backend={HTML5Backend}>
              <ReceiptCanvas />
            </DndProvider>
          )}
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
