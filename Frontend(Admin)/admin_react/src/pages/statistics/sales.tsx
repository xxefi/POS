import { useTranslation } from "react-i18next";
import { useEffect } from "react";
import { saleData, salesData } from "../../components/interfaces/cards.data";
import SalesChart from "../../components/cards/statistics/card_sales/sales";
import SaleChart from "../../components/cards/statistics/card_sales/sale";

export default function Sales() {
  const { t } = useTranslation("common");

  useEffect(() => {
    document.title = t("sales");
  }, []);

  return (
    <div>
      <span className="text-gray-500 font-medium text-xl">{t("sales")}</span>
      <div className="mt-4 flex gap-4">
        {salesData.map((data, index) => (
          <SalesChart
            key={index}
            title={t(data.title)}
            amount={data.amount}
            amountType={data.amountType}
          />
        ))}
      </div>
      <div className="flex mt-6">
        <span className="text-gray-500 font-medium text-xl">{t("sale")}</span>
      </div>
      <div className="flex">
        {saleData.map((data, index) => (
          <SaleChart
            key={index}
            title={t(data.title)}
            month={t(data.month)}
            totalAmount={data.totalAmount}
          />
        ))}
      </div>
    </div>
  );
}
