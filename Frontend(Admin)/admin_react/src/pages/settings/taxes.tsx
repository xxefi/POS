import { useEffect } from "react";
import { useTranslation } from "react-i18next";

export default function Taxes() {
  const { t } = useTranslation("common");
  useEffect(() => {
    document.title = t("taxes");
  }, []);
  return (
    <div>
      <span className="text-gray-500 font-medium text-xl">{t("taxes")}</span>
    </div>
  );
}
