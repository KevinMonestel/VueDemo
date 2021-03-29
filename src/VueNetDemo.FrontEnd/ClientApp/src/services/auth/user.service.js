import VueJwtDecode from "vue-jwt-decode";

class UserService {
  getUserClaims(){
    if(this.$store.state.auth.user){
        let decoded = VueJwtDecode.decode(this.$store.state.auth.user.token)
        return decoded;
      }
      return null;
  }
}

export default new UserService();