import { useTranslation } from "react-i18next";
import { useEffect } from "react";
import { dashboardData } from "../../components/interfaces/cards.data";
import SaleCard from "../../components/cards/statistics/card_dashboard/sale";
import FinanceCard from "../../components/cards/statistics/card_dashboard/finance";

export default function Dashboard() {
  const { t } = useTranslation("common");
  useEffect(() => {
    document.title = t("dashboard");
  }, []);
  return (
    <div>
      <span className="text-gray-500 font-medium text-xl">
        {t("dashboard")}
      </span>

      <div className="space-y-6">
        <h4 className="text-xl text-gray-500 mt-4">{t("sales")}</h4>
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-2 lg:grid-cols-6 gap-3 mt-5">
          {dashboardData.map((card, index) => (
            <div key={index} className="pb-3">
              <SaleCard
                key={index}
                title={t(card.title)}
                yesterdayAmount={card.yesterdayAmount}
                amount={card.amount}
                amountType={card.amountType}
                percentage={card.percentage}
                percentageColor={card.percentageColor}
              />
            </div>
          ))}
        </div>
        <div className="space-y-6">
          <h4 className="text-xl text-gray-500 mt-4">{t("finances")}</h4>
          <FinanceCard />
        </div>
      </div>
    </div>
  );
}
