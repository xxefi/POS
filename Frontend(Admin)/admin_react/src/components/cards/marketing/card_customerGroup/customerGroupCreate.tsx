import { ChangeEvent, useEffect, useState } from "react";
import { Button, TextField } from "@mui/material";
import { useTranslation } from "react-i18next";
import CheckIcon from "@mui/icons-material/Check";
import { useNavigate } from "react-router-dom";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";

export default function CustomerGroupCreate() {
  const { t } = useTranslation("common");
  const [formData, setFormData] = useState<{
    name: string;
    discount: number;
  }>({
    name: "",
    discount: 0,
  });

  const [hasChanges, setHasChanges] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    document.title = t("create");
  }, []);

  const handleBack = () => {
    if (hasChanges) {
      const confirmLeave = window.confirm(t("unsavedChangesMessage"));
      if (!confirmLeave) return;
    }
    navigate(-1);
  };

  const handleInputChange = (
    e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;

    if (name === "discount" || name === "balance") {
      const numericValue = parseFloat(value);
      setFormData((prevData) => ({
        ...prevData,
        [name]: isNaN(numericValue) ? 0 : numericValue,
      }));
    } else {
      setFormData((prevData) => ({
        ...prevData,
        [name]: value,
      }));
    }

    setHasChanges(true);
  };

  return (
    <div className="flex flex-col">
      <span className="text-gray-500 font-medium text-xl mb-5">
        {t("customerGroup")} / {t("create")}
      </span>
      <div className="flex flex-col w-1/3">
        <div className="flex items-center mb-3">
          <label className="w-1/3 text-left">{t("name")}</label>
          <TextField
            name="name"
            value={formData.name}
            onChange={handleInputChange}
            variant="outlined"
            size="small"
            className="w-2/3 ml-4"
          />
        </div>

        <div className="flex items-center mb-3">
          <label className="w-1/3 text-left">{t("discountValue")}</label>
          <TextField
            name="discount"
            value={formData.discount || ""}
            onChange={handleInputChange}
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
            <span className="flex justify-center items-center">
              <ArrowBackIcon />
              <span className="ml-2">{t("back")}</span>
            </span>
          </Button>

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
    </div>
  );
}
