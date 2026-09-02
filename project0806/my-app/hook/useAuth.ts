"use client";

export function useAuth() {
  function logout() {
    const confirmLogout = window.confirm("確定要登出嗎？");
    if (confirmLogout) {
      // 使用者按「確定」
      window.location.href = `${process.env.NEXT_PUBLIC_FRONTEND_URL}/login`;
    }
  }

  return { logout };
}
