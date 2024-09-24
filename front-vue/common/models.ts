export interface User {
  avatar: string;
  username: string;
  displayname?: string
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
}
