import { CardData } from "../../../interfaces/cards.data.ts";
import { useTranslation } from "react-i18next";
import { formattedAmount } from "../../../interfaces/formatters.item.ts";
import { Panel, Divider, Stack } from "rsuite";

export default function SaleCard({
  title,
  yesterdayAmount,
  amount,
  amountType,
  percentage,
  percentageColor,
}: CardData) {
  const { t } = useTranslation("common");

  return (
    <div className="tw-whitespace-nowrap tw-mr-2">
      <Panel
        className="min-h-[140px] w-full flex justify-center items-center"
        bodyFill
        style={{
          boxShadow:
            "0px 4px 8px rgba(0, 0, 0, 0.05), 0px 12px 10px rgba(0, 0, 0, 0.1)",
          borderRadius: "8px",
        }}
      >
        <div className="p-8 w-72 text-center">
          <h4
            className="mb-1 overflow-hidden text-ellipsis whitespace-nowrap font-medium text-base"
            title={t(title)}
          >
            {t(title)}
          </h4>
          <span className="font-medium text-black">
            <span className="text-empty text-gray-600 text-base opacity-100 tw-block tw-truncate">
              {formattedAmount(amount, amountType, t)}
            </span>
          </span>
          <Divider className="my-2" />
          <Stack justifyContent="space-between" alignItems="center">
            <span className="text-gray-600 text-sm tw-truncate">
              {formattedAmount(yesterdayAmount, amountType, t)}
            </span>
            <Stack alignItems="center">
              <svg
                viewBox="0 0 24 24"
                role="presentation"
                className={`pr-1 ${percentageColor} w-3 h-3`}
              >
                <path
                  d="M22.1454 5H11.4659H1.84924C0.203599 5 -0.619219 7.12496 0.546441 8.37063L9.42603 17.8597C10.8488 19.3801 13.163 19.3801 14.5858 17.8597L17.9628 14.2509L23.4654 8.37063C24.6139 7.12496 23.7911 5 22.1454 5Z"
                  fill="currentColor"
                ></path>
              </svg>
              <span>{percentage}%</span>
            </Stack>
          </Stack>
        </div>
      </Panel>
    </div>
  );
}
