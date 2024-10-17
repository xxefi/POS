import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { Button } from "@mui/material";

export default function NotFound() {
  const { t } = useTranslation("common");
  const navigate = useNavigate();

  const handleBack = () => {
    navigate(-1);
  };

  return (
    <div className="flex flex-col items-center justify-center min-h-screen from-gray-100 to-red-200 text-center">
      <img
        loading="lazy"
        src="/404.png"
        alt="404"
        style={{ width: "250px", marginBottom: "20px" }}
      />
      <h1 className="text-6xl font-bold text-gray-800">404</h1>
      <h2 className="text-2xl font-semibold text-gray-700 mt-2">
        {t("pagenotfound")}
      </h2>
      <p className="text-gray-500 mt-4">{t("sorrymessage")}</p>
      <Button
        onClick={handleBack}
        variant="contained"
        style={{
          backgroundColor: "black",
          color: "white",
          marginTop: "24px",
          textTransform: "none",
          width: "240px",
          textWrap: "nowrap",
          borderRadius: "8px",
        }}
      >
        {t("back")}
      </Button>
    </div>
  );
}
