import { useEffect } from "react";
import { useTranslation } from "react-i18next";

export default function Terminal() {
  const { t } = useTranslation("common");
  useEffect(() => {
    document.title = t("terminal");
  }, []);
  return (
    <div>
      <span className="text-gray-500 font-medium text-xl">{t("terminal")}</span>
    </div>
  );
}
