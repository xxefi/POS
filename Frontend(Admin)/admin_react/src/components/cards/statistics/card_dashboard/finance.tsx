import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import { useTranslation } from "react-i18next";

export default function FinanceCard() {
  const { t } = useTranslation("common");
  const options = {
    credits: {
      enabled: false,
    },
    chart: {
      type: "column",
      width: 1600,
    },
    title: {
      text: "",
    },
    xAxis: {
      categories: [t("cash")],
    },
    yAxis: {
      title: {
        text: "",
      },
      gridLineWidth: 1,
      gridLineColor: "#e6e6e6",
      gridZIndex: 1,
    },
    series: [
      {
        name: "Income",
        data: [30],
        color: "#7cb5ec",
      },
    ],
    plotOptions: {
      column: {
        borderWidth: 1,
        borderColor: "#ffffff",
      },
    },
  };

  return (
    <div className="shadow rounded bg-white p-3" style={{ minHeight: "160px" }}>
      <div className="d-flex justify-content-between">
        <div className="d-flex">
          <h5 className="font-weight-light mb-3 mr-3">
            {t("profitabilityByPaymentMethod")}
          </h5>
        </div>
      </div>
      <HighchartsReact highcharts={Highcharts} options={options} />
    </div>
  );
}
