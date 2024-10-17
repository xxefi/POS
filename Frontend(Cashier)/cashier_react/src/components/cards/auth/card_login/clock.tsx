import { useEffect, useState } from "react";
import { useTranslation } from "react-i18next";

export default function Clock() {
  const [currentTime, setCurrentTime] = useState<string>("");
  const { t } = useTranslation("common");

  useEffect(() => {
    const updateTime = () => {
      const now = new Date();
      setCurrentTime(now.toLocaleString());
    };

    updateTime();
    const interval = setInterval(updateTime, 1000);

    return () => clearInterval(interval);
  }, []);

  return (
    <div className="absolute top-0 left-0 p-6 mt-2 bg-white rounded-xl text-lg font-bold text-gray-800">
      <span>
        {currentTime}, {t("currentLanguage")}
      </span>
    </div>
  );
}
