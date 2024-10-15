import {useTranslation} from "react-i18next";
import {Dispatch, SetStateAction, useState} from "react";
import {useNavigate} from "react-router-dom";
import {Button, FormControl, Select, TextField} from "@mui/material";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import CheckIcon from "@mui/icons-material/Check";

export default function ProductCreate() {
  const { t } = useTranslation("common");
  const [name, setName] = useState<string>("");
  const [category, setCategory] = useState<string>("");
  const [price, setPrice] = useState<number | string>(0);
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

    const handleStringChange = (setter: Dispatch<SetStateAction<string>>, value: string) => {
        setter(value);
        setHasChanges(true);
    };

    const handleNumberChange = (setter: Dispatch<SetStateAction<number | string>>, value: number | string) => {
        setter(value);
        setHasChanges(true);
    };

  return (
      <div className="flex flex-col">
      <span className="text-gray-500 font-medium text-xl mb-5">
        {t("products")} / {t("create")}
      </span>
          <div className="flex flex-col w-1/3">
              <div className="flex items-center mb-2 h-[40px]">
                  <label className="w-1/3 text-left">{t("name")}</label>
                  <TextField
                      value={name}
                      onChange={(e) => handleStringChange(setName, e.target.value)}
                      variant="outlined"
                      size="small"
                      className="w-2/3 ml-4"
                  />
              </div>

              <div className="flex items-center mb-3">
                  <label className="w-1/3 text-left">{t("category")}</label>
                  <FormControl variant="outlined" size="small" className="w-2/3 ml-4">
                      <Select
                          labelId="category-label"
                          value={category}
                          onChange={(e) => handleStringChange(setCategory, e.target.value)}
                          label={t("category")}
                      >
                      </Select>
                  </FormControl>
              </div>

              <div className="flex items-center mb-3">
                  <label className="w-1/3 text-left">{t("price")}</label>
                  <TextField
                      value={price}
                      onChange={(e) => handleNumberChange(setPrice, e.target.value)}
                      variant="outlined"
                      size="small"
                      className="w-2/3 ml-4"
                      type="number"
                  />
              </div>

              <div className="flex justify-between">
                  <Button
                      variant="contained"
                      className="mt-2 w-[130px] h-[35px] shadow-none"
                      startIcon={<ArrowBackIcon/>}
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
                      startIcon={<CheckIcon/>}
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
