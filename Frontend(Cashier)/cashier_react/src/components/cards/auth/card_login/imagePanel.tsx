import { useTranslation } from "react-i18next";

export default function ImagePanel() {
  const { t } = useTranslation("common");

  return (
    <div className="w-1/2 relative">
      <img
        src="../src/assets/restaurant.jpg"
        alt={t("restaurantAltText")}
        className="object-cover w-full h-full opacity-80"
      />
    </div>
  );
}
