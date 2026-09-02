"use client";

import { useAuth } from "@/hook/useAuth";

export default function Home() {
  const { logout } = useAuth();

  return (
    <main className="min-h-screen flex flex-col items-center justify-center gap-4">
      <h1 className="text-4xl font-bold">好愛...王月...?</h1>
      <button
        type="button"
        onClick={logout}
        className="rounded-lg border border-transparent bg-black px-4 py-2 text-sm font-medium text-white hover:bg-black/80 dark:bg-white dark:text-black dark:hover:bg-white/80"
      >
        登出
      </button>
    </main>
  );
}
