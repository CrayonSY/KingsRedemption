using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    
    void Update()
    {
        // �}�E�X�ʒu���W���i�[����
        Vector3 position = Input.mousePosition;
        // Z���̏C��
        position.z = 10f;
        // �}�E�X�ʒu���W���X�N���[�����W���烏�[���h���W�ɕϊ�����
        Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        // ���[���h���W�ɕϊ����ꂽ�}�E�X���W�ƒǏ]���������I�u�W�F�N�g�̋����𑪂�A��������鑬�x�������̂����݈ʒu�ɉ��Z���Ă���
        gameObject.transform.position = screenToWorldPointPosition;
    }
}
