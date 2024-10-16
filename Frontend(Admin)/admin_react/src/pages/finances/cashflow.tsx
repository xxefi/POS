import { useEffect } from "react";
import { useTranslation } from "react-i18next";

export default function CashFlow() {
  const { t } = useTranslation("common");
  useEffect(() => {
    document.title = t("cashflow");
  }, []);
  return (
    <div>
      <span className="text-gray-500 font-medium text-xl">{t("cashflow")}</span>
      <div className="flex flex-col items-center justify-center h-screen">
        <span className="font-medium">{t("noDataFound")}</span>
      </div>
    </div>
  );
}
