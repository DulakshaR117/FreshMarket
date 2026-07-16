import { FiSearch } from "react-icons/fi";

function SearchBar() {
  return (
    <div className="relative">

      <FiSearch className="absolute left-5 top-1/2 -translate-y-1/2 text-gray-400 text-xl" />

      <input
        type="text"
        placeholder="Search fresh products..."
        className="
          w-full
          rounded-full
          border
          px-14
          py-4
          outline-none
          focus:ring-2
          focus:ring-green-500
        "
      />

    </div>
  );
}

export default SearchBar;