const API_URL = process.env.NEXT_PUBLIC_API_URL;

export interface ApiResult {
  ok: boolean;
  data: string;
}

export async function loginApi(
  account: string,
  password: string,
): Promise<ApiResult> {
  const response = await fetch(`${API_URL}/api/Login`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ account, password }),
  });

  const data = await response.text();
  return { ok: response.ok, data };
}

export async function registerApi(
  account: string,
  password: string,
  userName: string,
): Promise<ApiResult> {
  const response = await fetch(`${API_URL}/api/Register`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ account, password, userName }),
  });

  const data = await response.text();
  return { ok: response.ok, data };
}
