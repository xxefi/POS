import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import { SaleChartProps } from "../../../interfaces/cards.data.ts";
import Accessibility from "highcharts/modules/accessibility";
import { formattedAmount } from "../../../interfaces/formatters.item.ts";
import { useTranslation } from "react-i18next";

Accessibility(Highcharts);

export default function SaleChart({
  title,
  month,
  totalAmount,
}: SaleChartProps) {
  const { t } = useTranslation("common");

  const generateChartData = () => {
    return Array.from({ length: 8 }, (_, i) => totalAmount * (i + 1));
  };

  const chartData = generateChartData();

  const options = {
    chart: {
      type: "area",
      backgroundColor: "transparent",
      height: "100%",
      style: {
        fontFamily: "Inter, sans-serif",
      },
    },
    title: {
      text: `${t(`months.${month}`)} - 2024`,
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
      area: {
        fillOpacity: 0.3,
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
        name: t(title),
        data: chartData,
        color: "#009bff",
      },
    ],
    xAxis: {
      categories: Array.from({ length: 31 }, (_, i) => (i + 1).toString()),
      labels: {
        style: {
          color: "#999999",
          fontSize: "10px",
        },
      },
      lineColor: "transparent",
      tickColor: "transparent",
    },
    yAxis: {
      title: {
        text: "",
      },
      gridLineColor: "transparent",
      labels: {
        enabled: true,
      },
    },
    credits: {
      enabled: false,
    },
  };

  return (
    <div
      style={{
        width: "100%",
        height: "300px",
        backgroundColor: "#f8f9fc",
        borderRadius: "10px",
        boxShadow: "0 4px 8px rgba(0, 0, 0, 0.1)",
        padding: "5px",
        display: "flex",
        flexDirection: "column",
        justifyContent: "space-between",
        marginTop: "20px",
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
        {t(title)}
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
        {formattedAmount(totalAmount, "currency", t)}
      </span>
      <div style={{ flex: 1 }}>
        <HighchartsReact
          highcharts={Highcharts}
          options={options}
          containerProps={{ style: { height: "100%" } }}
        />
      </div>
    </div>
  );
}
