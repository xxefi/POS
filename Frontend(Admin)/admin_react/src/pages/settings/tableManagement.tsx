import { useEffect } from "react";
import { useTranslation } from "react-i18next";

export default function TableManagement() {
  const { t } = useTranslation("common");
  useEffect(() => {
    document.title = t("tableManagement");
  }, []);
  return (
    <div>
      <span className="text-gray-500 font-medium text-xl">
        {t("tableManagement")}
      </span>
    </div>
  );
}
