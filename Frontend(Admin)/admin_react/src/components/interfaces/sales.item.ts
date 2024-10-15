export interface SalesItem {
  to: string;
  label: string;
}

export const salesItem: SalesItem[] = [
  { to: "/sale/receipts", label: "receipts" },
  { to: "/sale/orderNotifications", label: "ordernotifications" },
  { to: "/sale/productReturn", label: "productreturn" },
  { to: "/sale/paymentMethods", label: "paymentmethods" },
  { to: "/sale/salesMethods", label: "salesmethods" },
];
