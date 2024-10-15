import { ChangeEvent, useEffect, useState } from "react";
import {
  Button,
  TextField,
  MenuItem,
  Select,
  FormControl,
  TextareaAutosize,
  SelectChangeEvent,
} from "@mui/material";
import { useTranslation } from "react-i18next";
import CheckIcon from "@mui/icons-material/Check";
import { useNavigate } from "react-router-dom";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

interface FormData {
  name: string;
  email: string;
  address: string;
  phone: number;
  description: string;
  group: string;
  code: number;
  gender: string;
  dob: Date | null;
}

export default function CustomerCreate() {
  const { t } = useTranslation("common");
  const [formData, setFormData] = useState<FormData>({
    name: "",
    email: "",
    address: "",
    phone: 0,
    description: "",
    group: "",
    code: 0,
    gender: "",
    dob: null,
  });
  const [hasChanges, setHasChanges] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    document.title = t("create");
  }, [t]);

  const handleBack = () => {
    if (hasChanges) {
      const confirmLeave = window.confirm(t("unsavedChangesMessage"));
      if (!confirmLeave) return;
    }
    navigate(-1);
  };

  const handleInputChange = (
    e:
      | ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
      | SelectChangeEvent<string>
  ) => {
    const { name, value } = e.target as
      | HTMLInputElement
      | { name: string; value: string };

    if (name === "phone" || name === "code") {
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

  const handleDateChange = (date: Date | null) => {
    setFormData((prevData) => ({
      ...prevData,
      dob: date,
    }));
    setHasChanges(true);
  };

  return (
    <div className="flex flex-col">
      <span className="text-gray-500 font-medium text-xl mb-5">
        {t("customers")} / {t("create")}
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
          <label className="w-1/3 text-left">{t("email")}</label>
          <TextField
            name="email"
            value={formData.email}
            onChange={handleInputChange}
            variant="outlined"
            size="small"
            className="w-2/3 ml-4"
          />
        </div>

        <div className="flex items-center mb-3">
          <label className="w-1/3 text-left">{t("address")}</label>
          <TextField
            name="address"
            value={formData.address}
            onChange={handleInputChange}
            variant="outlined"
            size="small"
            className="w-2/3 ml-4"
          />
        </div>

        <div className="flex items-center mb-3">
          <label className="w-1/3 text-left">{t("phone")}</label>
          <TextField
            name="phone"
            value={formData.phone || ""}
            onChange={handleInputChange}
            variant="outlined"
            size="small"
            className="w-2/3 ml-4"
          />
        </div>

        <div className="flex items-start mb-3">
          <label className="w-1/3 text-left">{t("description")}</label>
          <TextareaAutosize
            name="description"
            value={formData.description}
            onChange={handleInputChange}
            minRows={4}
            className="w-2/3 border border-gray-300 p-2 rounded-md"
          />
        </div>

        <div className="flex items-center mb-3">
          <label className="w-1/3 text-left">{t("group")}</label>
          <FormControl variant="outlined" size="small" className="w-2/3 ml-4">
            <Select
              name="group"
              value={formData.group}
              onChange={handleInputChange}
            ></Select>
          </FormControl>
        </div>

        <div className="flex items-center mb-3">
          <label className="w-1/3 text-left">{t("code")}</label>
          <TextField
            name="code"
            value={formData.code || ""}
            onChange={handleInputChange}
            variant="outlined"
            size="small"
            className="w-2/3 ml-4"
          />
        </div>

        <div className="flex items-center mb-3">
          <label className="w-1/3 text-left">{t("gender")}</label>
          <FormControl variant="outlined" size="small" className="w-2/3 ml-4">
            <Select
              name="gender"
              value={formData.gender}
              onChange={handleInputChange}
            >
              <MenuItem value="male">{t("male")}</MenuItem>
              <MenuItem value="female">{t("female")}</MenuItem>
            </Select>
          </FormControl>
        </div>

        <div className="flex items-center mb-3">
          <label className="w-1/3 text-left">{t("dob")}</label>
          <div className="w-2/3">
            <DatePicker
              selected={formData.dob}
              onChange={handleDateChange}
              dateFormat="yyyy-MM-dd"
              className="border border-gray-300 rounded-md shadow-sm p-2 h-10 w-full focus:outline-none focus:ring focus:ring-blue-500"
              placeholderText={t("selectDate")}
              isClearable
              popperPlacement="right"
            />
          </div>
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
              <span className="flex">
                <ArrowBackIcon />
              </span>
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
              <span className="flex">
                <CheckIcon />
              </span>
            </span>
            <span className="ml-2">{t("save")}</span>
          </Button>
        </div>
      </div>
    </div>
  );
}
