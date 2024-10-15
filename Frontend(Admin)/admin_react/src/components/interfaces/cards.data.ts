export interface CardData {
  title: string;
  yesterdayAmount: number;
  amount: number;
  percentage: number;
  percentageColor: string;
  amountType: "currency" | "number" | "time";
}

export interface SalesChartProps {
  title: string;
  amount: number;
  amountType: "currency" | "number" | "time";
}

export interface SaleChartProps {
  title: string;
  month: string;
  totalAmount: number;
}

export const dashboardData: CardData[] = [
  {
    title: "revenue",
    yesterdayAmount: 0,
    amount: 0,
    amountType: "currency",
    percentage: 100,
    percentageColor: "text-green-700",
  },
  {
    title: "totalProfit",
    yesterdayAmount: 0,
    amount: 0,
    amountType: "currency",
    percentage: 100,
    percentageColor: "text-green-700",
  },
  {
    title: "averageReceiptAmount",
    yesterdayAmount: 0,
    amount: 0,
    amountType: "currency",
    percentage: 100,
    percentageColor: "text-green-700",
  },
  {
    title: "receipts",
    yesterdayAmount: 0,
    amount: 0,
    amountType: "number",
    percentage: 100,
    percentageColor: "text-green-700",
  },
  {
    title: "guests",
    yesterdayAmount: 0,
    amount: 0,
    amountType: "number",
    percentage: 100,
    percentageColor: "text-green-700",
  },
  {
    title: "averageTime",
    yesterdayAmount: 0,
    amount: 0,
    amountType: "time",
    percentage: 100,
    percentageColor: "text-green-700",
  },
  {
    title: "serviceCharge",
    yesterdayAmount: 0,
    amount: 0,
    amountType: "currency",
    percentage: 100,
    percentageColor: "text-green-700",
  },
  {
    title: "totalDiscount",
    yesterdayAmount: 0,
    amount: 0,
    amountType: "currency",
    percentage: 100,
    percentageColor: "text-green-700",
  },
  {
    title: "tax",
    yesterdayAmount: 0,
    amount: 0,
    amountType: "currency",
    percentage: 100,
    percentageColor: "text-green-700",
  },
  {
    title: "totalReturnedAmount",
    yesterdayAmount: 0,
    amount: 0,
    amountType: "currency",
    percentage: 100,
    percentageColor: "text-green-700",
  },
  {
    title: "closedUnpaidReceipts",
    yesterdayAmount: 0,
    amount: 0,
    amountType: "currency",
    percentage: 100,
    percentageColor: "text-green-700",
  },
  {
    title: "deliveryFee",
    yesterdayAmount: 0,
    amount: 0,
    amountType: "currency",
    percentage: 100,
    percentageColor: "text-green-700",
  },
];

export const salesData: SalesChartProps[] = [
  { title: "revenue", amount: 0, amountType: "currency" },
  { title: "totalProfit", amount: 0, amountType: "currency" },
  { title: "averageReceiptAmount", amount: 0, amountType: "currency" },
  { title: "receipts", amount: 0, amountType: "number" },
  { title: "guests", amount: 0, amountType: "number" },
  { title: "averageTime", amount: 0, amountType: "time" },
];

export const saleData: SaleChartProps[] = [
  { month: "january", totalAmount: 1200, title: "sale" },
  { month: "february", totalAmount: 1500, title: "sale" },
  { month: "march", totalAmount: 1300, title: "sale" },
  { month: "april", totalAmount: 1800, title: "sale" },
  { month: "may", totalAmount: 1600, title: "sale" },
  { month: "june", totalAmount: 2000, title: "sale" },
  { month: "july", totalAmount: 2200, title: "sale" },
  { month: "august", totalAmount: 2400, title: "sale" },
];
