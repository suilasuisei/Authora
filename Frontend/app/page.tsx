"use client";

import { Button } from "@/components/ui/button";
import { useAuth } from "@/hook/useAuth";

export default function Home() {
  return (
    <main className="min-h-screen flex flex-col items-center justify-center gap-4">
      <h1 className="text-4xl font-bold">好愛...王月...?</h1>
      <Button type="button">登出</Button>
    </main>
  );
}
