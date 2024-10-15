import {Dispatch, SetStateAction, useEffect, useState} from "react";
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

export default function CategoryCreate() {
  const { t } = useTranslation("common");
  const [name, setName] = useState<string>("");
  const [type, setType] = useState<string>("");
  const [hasChanges, setHasChanges] = useState<boolean>(false);
  const navigate = useNavigate();

  useEffect(() => {
    document.title = t("create");
  }, []);

    const handleBack = () => {
        if (hasChanges) {
            const confirmLeave = window.confirm(
                t("unsavedChangesMessage") || "You have unsaved changes. Are you sure you want to leave?"
            );
            if (!confirmLeave) return;
        }
        navigate(-1);
    };

    const handleInputChange = (setter: Dispatch<SetStateAction<string>>, value: string) => {
        setter(value);
        setHasChanges(true);
    };


    return (
    <div className="flex flex-col">
      <span className="text-gray-500 font-medium text-xl mb-5">
        {t("categories")} / {t("create")}
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
          <label className="w-1/3 text-left">{t("type")}</label>
          <FormControl variant="outlined" size="small" className="w-2/3 ml-4">
            <Select
              value={type}
              onChange={(e) => handleInputChange(setType ,e.target.value)}
              label={t("type")}
            >
              <MenuItem value="income">{t("income")}</MenuItem>
              <MenuItem value="expense">{t("expense")}</MenuItem>
              <MenuItem value="both">{t("both")}</MenuItem>
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
