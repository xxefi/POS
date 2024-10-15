import { useEffect } from "react";
import { useTranslation } from "react-i18next";

export default function Subscriptions() {
  const { t } = useTranslation("common");
  useEffect(() => {
    document.title = t("subscriptions");
  }, []);
  return (
    <div>
      <span className="text-gray-500 font-medium text-xl">
        {t("subscriptions")}
      </span>
    </div>
  );
}
