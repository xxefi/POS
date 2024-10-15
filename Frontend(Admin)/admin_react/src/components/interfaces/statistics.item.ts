export interface StatisticsItem {
  to: string;
  label: string;
}

export const statisticsItem: StatisticsItem[] = [
  { to: "/statistics/dashboard", label: "dashboard" },
  { to: "/statistics/sales", label: "sales" },
  { to: "/statistics/reports", label: "reports" },
  { to: "/statistics/history", label: "history" },
];
