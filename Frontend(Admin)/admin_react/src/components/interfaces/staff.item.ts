export interface StaffItem {
  to: string;
  label: string;
}

export const staffItem: StaffItem[] = [
  { to: "/staff/users", label: "users" },
  { to: "/staff/roles", label: "roles" },
];
