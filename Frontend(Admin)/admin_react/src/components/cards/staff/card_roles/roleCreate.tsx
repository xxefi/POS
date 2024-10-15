import { Dispatch, SetStateAction, useEffect, useState } from "react";
import { Button, TextField, Checkbox, FormControlLabel } from "@mui/material";
import { useTranslation } from "react-i18next";
import CheckIcon from "@mui/icons-material/Check";
import { useNavigate } from "react-router-dom";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";

export default function RoleCreate() {
  const { t } = useTranslation("common");
  const [roleName, setRoleName] = useState<string>("");
  const [isSeller, setIsSeller] = useState<boolean>(false);
  const [isCourier, setIsCourier] = useState<boolean>(false);
  const [hasChanges, setHasChanges] = useState<boolean>(false);
  const navigate = useNavigate();

  useEffect(() => {
    document.title = t("createRole");
  }, [t]);

  const handleInputChange = (
    setter: Dispatch<SetStateAction<any>>,
    value: any
  ) => {
    setter(value);
    setHasChanges(true);
  };

  const handleCheckboxChange = (
    setter: Dispatch<SetStateAction<boolean>>,
    checked: boolean
  ) => {
    setter(checked);
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
        {t("roles")} / {t("create")}
      </span>
      <div className="flex flex-col w-1/3">
        <div className="flex items-center mb-2 h-[40px]">
          <label className="w-1/3 text-left">{t("roleName")}</label>
          <TextField
            value={roleName}
            onChange={(e) => handleInputChange(setRoleName, e.target.value)}
            variant="outlined"
            size="small"
            className="w-2/3 ml-4"
          />
        </div>

        <div className="flex items-center mb-2">
          <label className="w-1/3 text-left">{t("seller")}</label>
          <FormControlLabel
            control={
              <Checkbox
                checked={isSeller}
                onChange={(e) =>
                  handleCheckboxChange(setIsSeller, e.target.checked)
                }
                name="seller"
                color="primary"
              />
            }
            label={t("seller")}
            className="w-2/3 ml-4"
          />
        </div>

        <div className="flex items-center mb-2">
          <label className="w-1/3 text-left">{t("courier")}</label>
          <FormControlLabel
            control={
              <Checkbox
                checked={isCourier}
                onChange={(e) =>
                  handleCheckboxChange(setIsCourier, e.target.checked)
                }
                name="courier"
                color="primary"
              />
            }
            label={t("courier")}
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
    </div>
  );
}
