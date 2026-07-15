import api from "../api/api";

export const getProducts = async () => {
  const response = await api.get("/Products");
  return response.data;
};

export const getProduct = async (id) => {
  const response = await api.get(`/Products/${id}`);
  return response.data;
};