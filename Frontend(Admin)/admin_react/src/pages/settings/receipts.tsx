import { useEffect } from "react";
import { useTranslation } from "react-i18next";

export default function Receipts() {
  const { t } = useTranslation("common");

  useEffect(() => {
    document.title = t("receipts");
  }, []);
  return (
    <div>
      <span className="text-gray-500 font-medium text-xl">{t("receipts")}</span>
    </div>
  );
}
