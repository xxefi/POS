import {
  Button,
  FormControl,
  MenuItem,
  Select,
  TextField,
} from "@mui/material";
import { Dispatch, SetStateAction, useEffect, useState } from "react";
import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";
import CheckIcon from "@mui/icons-material/Check";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";

export default function TaxeCreate() {
  const { t } = useTranslation("common");
  const [name, setName] = useState<string>("");
  const [percentAge, setPercentAge] = useState<number>(0);
  const [type, setType] = useState<string>("");
  const [priority, setPriority] = useState<number>(0);
  const [hasChanges, setHasChanges] = useState<boolean>(false);
  const navigate = useNavigate();

  useEffect(() => {
    document.title = t("create");
  }, [t]);

  const handleInputChange = (
    setter: Dispatch<SetStateAction<any>>,
    value: any
  ) => {
    setter(value);
    setHasChanges(true);
  };

  const handleBack = () => {
    if (hasChanges) {
      const confirmLeave = window.confirm(t("unsavedChangesMessage"));
      if (!confirmLeave) return;
    }
    navigate(-1);
  };

  return (
    <div className="flex flex-col">
      <span className="text-gray-500 font-medium text-xl mb-5">
        {t("taxes")} / {t("create")}
      </span>

      <div className="flex items-center mb-2">
        <label className="w-1/3 text-left">{t("name")}</label>
        <TextField
          value={name}
          onChange={(e) => handleInputChange(setName, e.target.value)}
          variant="outlined"
          size="small"
          className="w-2/3 ml-4"
        />
      </div>

      <div className="flex items-center mb-2">
        <label className="w-1/3 text-left">{t("percentAge")}</label>
        <TextField
          type="number"
          value={percentAge}
          onChange={(e) =>
            handleInputChange(setPercentAge, Number(e.target.value))
          }
          variant="outlined"
          size="small"
          className="w-2/3 ml-4"
        />
      </div>

      <div className="flex items-center mb-2">
        <label className="w-1/3 text-left">{t("type")}</label>
        <FormControl variant="outlined" size="small" className="w-2/3 ml-4">
          <Select
            value={type}
            onChange={(e) => handleInputChange(setType, e.target.value)}
          >
            <MenuItem value="income">{t("income")}</MenuItem>
            <MenuItem value="sales">{t("sales")}</MenuItem>
          </Select>
        </FormControl>
      </div>

      <div className="flex items-center mb-2">
        <label className="w-1/3 text-left">{t("priority")}</label>
        <TextField
          type="number"
          value={priority}
          onChange={(e) =>
            handleInputChange(setPriority, Number(e.target.value))
          }
          variant="outlined"
          size="small"
          className="w-2/3 ml-4"
        />
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
  );
}
