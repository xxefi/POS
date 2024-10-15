import { Dispatch, SetStateAction, useEffect, useState} from "react";
import {
    Button,
    TextField,
    MenuItem,
    Select,
    FormControl,
} from "@mui/material";
import { useTranslation } from "react-i18next";
import CheckIcon from "@mui/icons-material/Check";
import { useNavigate } from "react-router-dom";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";

export default function SaleMethodCreate() {
  const { t } = useTranslation("common");
  const [name, setName] = useState<string>("");
  const [saleChanel, setSaleChanel] = useState<string>("");
  const [paymentMethod, setPaymentMethod] = useState<string>("");
  const [hasChanges, setHasChanges] = useState<boolean>(false);
  const navigate = useNavigate();

    const handleBack = () => {
        if (hasChanges) {
            const confirmLeave = window.confirm(
                t("unsavedChangesMessage") || "You have unsaved changes. Are you sure you want to leave?"
            );
            if (!confirmLeave) return;
        }
        navigate(-1);
    };

  useEffect(() => {
    document.title = t("create");
  }, [t]);

    const handleInputChange = (setter: Dispatch<SetStateAction<string>>, value: string) => {
        setter(value);
        setHasChanges(true);
    };


    return (
    <div className="flex flex-col">
      <span className="text-gray-500 font-medium text-xl mb-5">
        {t("salesmethods")} / {t("create")}
      </span>
      <div className="flex flex-col w-1/3">
        <div className="flex items-center mb-2 h-[40px]">
          <label className="w-1/3 text-left">{t("name")}</label>
          <TextField
            value={name}
            onChange={(e) => handleInputChange(setName, e.target.value)}
            variant="outlined"
            size="small"
            className="w-2/3 ml-4"
          />
        </div>

        <div className="flex items-center mb-3">
          <label className="w-1/3 text-left">{t("saleChanel")}</label>
          <FormControl variant="outlined" size="small" className="w-2/3 ml-4">
            <Select
              labelId="saleChanel-label"
              value={saleChanel}
              onChange={(e) => handleInputChange(setSaleChanel, e.target.value)}
              label={t("saleChanel")}
            >
              <MenuItem value="delivery">{t("delivery")}</MenuItem>
              <MenuItem value="takeaway">{t("takeaway")}</MenuItem>
            </Select>
          </FormControl>
        </div>

        <div className="flex items-center mb-3">
          <label className="w-1/3 text-left">{t("paymentMethod")}</label>
          <FormControl variant="outlined" size="small" className="w-2/3 ml-4">
            <Select
              labelId="paymentMethod-label"
              value={paymentMethod}
              onChange={(e) => handleInputChange(setPaymentMethod, e.target.value)}
              label={t("paymentMethod")}
            >
              <MenuItem value="creditCard">{t("cash")}</MenuItem>
              <MenuItem value="card">{t("card")}</MenuItem>
              <MenuItem value="customerBalance">
                {t("customerBalance")}
              </MenuItem>
              <MenuItem value="cashback">{t("cashback")}</MenuItem>
            </Select>
          </FormControl>
        </div>

        <div className="flex justify-between">
          <Button
            variant="contained"
            className="mt-2 w-[130px] h-[35px] shadow-none"
            startIcon={<ArrowBackIcon />}
            onClick={handleBack}
            sx={{
              backgroundColor: "#f44336",
              color: "white",
              textTransform: "none",
              boxShadow: "none",
              borderRadius: "10px",
              marginRight: "8px",
              "&:hover": {
                backgroundColor: "#c62828",
              },
            }}
          >
            <span>{t("back")}</span>
          </Button>

          <Button
            variant="contained"
            className="mt-2 w-[130px] h-[35px] shadow-none"
            startIcon={<CheckIcon />}
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
            <span>{t("save")}</span>
          </Button>
        </div>
      </div>
    </div>
  );
}
