export default function({ $auth, redirect }) {
  if ($auth.user.role != "Customer") {
    return redirect("/");
  }
}
