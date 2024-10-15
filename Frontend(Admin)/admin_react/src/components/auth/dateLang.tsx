import LanguageSwitcher from "../../language";

interface DateLangProps {
  currentDateTime: string;
  currentLanguage: string;
}

export default function DateLang({
  currentDateTime,
  currentLanguage,
}: DateLangProps) {
  return (
    <div className="absolute top-4 right-4 flex items-center bg-white p-5 justify-center rounded-lg">
      <div className="mr-5 text-gray-700">{currentDateTime}</div>
      <LanguageSwitcher />
      <span className="ml-2 text-gray-700">{currentLanguage}</span>
    </div>
  );
}
