function SortDropdown() {
  return (
    <select className="border rounded-full px-5 py-3 outline-none">

      <option>Newest</option>

      <option>Price: Low to High</option>

      <option>Price: High to Low</option>

      <option>Best Rated</option>

    </select>
  );
}

export default SortDropdown;