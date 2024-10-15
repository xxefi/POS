export interface MarketingItem {
  to: string;
  label: string;
}

export const marketingItem: MarketingItem[] = [
  { to: "/marketing/customers", label: "customers" },
  { to: "/marketing/customerGroup", label: "customerGroup" },
  { to: "/marketing/reviews", label: "reviews" },
];
