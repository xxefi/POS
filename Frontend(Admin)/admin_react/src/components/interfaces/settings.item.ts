export interface SettingsItem {
  to: string;
  label: string;
}

export const settingsItem: SettingsItem[] = [
  { to: "/settings/general", label: "general" },
  { to: "/settings/terminal", label: "terminal" },
  { to: "/settings/taxes", label: "taxes" },
  { to: "/settings/receipts", label: "receipts" },
  { to: "/settings/subscriptions", label: "subscriptions" },
  { to: "/settings/tableManagement", label: "tableManagement" },
];
