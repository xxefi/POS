import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import { SalesChartProps } from "../../../interfaces/cards.data.ts";
import Accessibility from "highcharts/modules/accessibility";
import { formattedAmount } from "../../../interfaces/formatters.item.ts";
import { useTranslation } from "react-i18next";

Accessibility(Highcharts);

export default function SalesChart({
  title,
  amount,
  amountType,
}: SalesChartProps) {
  const { t } = useTranslation("common");
  const generateChartData = (amount: number) => {
    return Array.from({ length: 12 }, (_, i) => amount * (i + 1) * 0.1);
  };

  const chartData = generateChartData(amount);

  const monthCategories = [
    t("months.january"),
    t("months.february"),
    t("months.march"),
    t("months.april"),
    t("months.may"),
    t("months.june"),
    t("months.july"),
    t("months.august"),
    t("months.september"),
    t("months.october"),
    t("months.november"),
    t("months.december"),
  ];

  const options = {
    chart: {
      type: "line",
      backgroundColor: "transparent",
      margin: [10, 10, 30, 10],
      height: 80,
      style: {
        fontFamily: "Inter, sans-serif",
      },
    },
    title: {
      text: "",
    },
    legend: {
      enabled: false,
    },
    tooltip: {
      shared: true,
      backgroundColor: "#fff",
      borderColor: "transparent",
      borderRadius: 5,
      style: {
        color: "#333333",
        fontSize: "11px",
        padding: "10px",
      },
    },
    plotOptions: {
      areaspline: {
        fillOpacity: 0.1,
        lineWidth: 1.5,
        marker: {
          enabled: false,
        },
        states: {
          hover: {
            lineWidth: 2,
          },
        },
      },
    },
    series: [
      {
        name: title,
        data: chartData,
        color: "#009bff",
      },
    ],
    xAxis: {
      categories: monthCategories,
      labels: {
        style: {
          color: "#999999",
          fontSize: "8px",
        },
        step: 2,
      },
      lineColor: "transparent",
      tickColor: "transparent",
    },
    yAxis: {
      gridLineColor: "transparent",
      title: {
        text: "",
      },
      labels: {
        enabled: false,
      },
    },
    credits: {
      enabled: false,
    },
  };

  return (
    <div
      style={{
        width: "265px",
        height: "150px",
        backgroundColor: "#f8f9fc",
        borderRadius: "10px",
        boxShadow: "0 4px 8px rgba(0, 0, 0, 0.1)",
        padding: "15px",
        display: "flex",
        flexDirection: "column",
        justifyContent: "space-between",
      }}
    >
      <span
        style={{
          fontSize: "14px",
          fontWeight: "bold",
          color: "#333333",
          textAlign: "center",
        }}
      >
        {title}
      </span>
      <span
        style={{
          fontSize: "20px",
          fontWeight: "500",
          opacity: "0.5",
          color: "#000",
          textAlign: "center",
        }}
      >
        {formattedAmount(amount, amountType, t)}
      </span>
      <div style={{ flex: 1 }}>
        <HighchartsReact highcharts={Highcharts} options={options} />
      </div>
    </div>
  );
}
