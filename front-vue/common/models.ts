export interface User {
  avatar: string;
  username: string;
  displayname?: string;
  bio?: string;
}

export interface Post {
  id: string;
  content: string;
  createdAt: Date;
  editedAt?: string;
  imageUrls?: string[];
  previousPostId?: string;
  commentCount :string;
  user: User;
}
export interface PostRequest {
  content: string;
  imageUrls?: string[];
  previousPostId?: string;
}
export interface Bookmark{
  postId :string;
}

export interface LoginResponse {
  token: string,
  username: string,
}
