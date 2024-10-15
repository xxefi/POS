import {
  Droppable,
  Draggable,
  DragDropContext,
  DropResult,
  DraggableProvided,
  DroppableProvided,
} from "react-beautiful-dnd";
import { CategoryMenuData } from "../../../interfaces/component.types";
import { useTranslation } from "react-i18next";
import { AiOutlineArrowsAlt } from "react-icons/ai";

interface CategoryListProps {
  categories: CategoryMenuData[];
  selectedCategory: CategoryMenuData | null;
  setSelectedCategory: (category: CategoryMenuData) => void;
  handleDragEnd: (result: DropResult) => void;
}

export function CategoryList({
  categories,
  selectedCategory,
  setSelectedCategory,
  handleDragEnd,
}: CategoryListProps) {
  const { t } = useTranslation("common");

  return (
    <div className="categories-list bg-white border border-gray-100 rounded-xl p-4">
      <h2 className="text-xl font-semibold mb-3 text-gray-500">
        {t("categories")}
      </h2>
      <DragDropContext onDragEnd={handleDragEnd}>
        <Droppable droppableId="categories">
          {(provided: DroppableProvided) => (
            <ul
              className="category-list"
              {...provided.droppableProps}
              ref={provided.innerRef}
            >
              {categories.length > 0 ? (
                categories.map((category, index) => (
                  <Draggable
                    key={category.id.toString()}
                    draggableId={category.id.toString()}
                    index={index}
                  >
                    {(provided: DraggableProvided) => (
                      <li
                        ref={provided.innerRef}
                        {...provided.draggableProps}
                        {...provided.dragHandleProps}
                        className={`category-item flex items-center justify-between p-3 mb-2 rounded-lg cursor-pointer transition duration-200 ease-in-out hover:bg-blue-50 ${
                          selectedCategory?.id === category.id
                            ? "bg-blue-200 text-blue-900"
                            : "bg-gray-100"
                        }`}
                        onClick={() => setSelectedCategory(category)}
                      >
                        <span>
                          {category.name} ({category.count})
                        </span>
                        <AiOutlineArrowsAlt className="text-gray-600" />
                      </li>
                    )}
                  </Draggable>
                ))
              ) : (
                <p className="text-red-500 font-medium">{t("noDataFound")}</p>
              )}
              {provided.placeholder}
            </ul>
          )}
        </Droppable>
      </DragDropContext>
    </div>
  );
}
