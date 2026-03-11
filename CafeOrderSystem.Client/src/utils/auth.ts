export const clearAuth = () => {
  localStorage.removeItem("token");
  localStorage.removeItem("userRole");
  window.dispatchEvent(new Event("authChanged"));
};
