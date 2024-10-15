export const formatTime = (minutes: number): string => {
  const days = Math.floor(minutes / (24 * 60));
  const hours = Math.floor((minutes % (24 * 60)) / 60);
  const mins = minutes % 60;

  return `${days}d ${hours}h ${mins}m`;
};

export const formattedAmount = (
  amount: number,
  amountType: string,
  t: (key: string) => string
) => {
  switch (amountType) {
    case "currency":
      return `${amount.toFixed(2)} ₼`;
    case "number":
      return `${amount} ${t("pcs")}`;
    case "time":
      return formatTime(amount);
    default:
      return amount;
  }
};
